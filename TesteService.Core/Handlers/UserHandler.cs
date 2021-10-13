using AutoMapper;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesteService.Core.Commands;
using TesteService.Core.Entities;
using TesteService.Core.Interfaces;
using TesteService.Core.Queries;
using TesteService.Core.Responses;
using TesteService.Core.Validations;

namespace TesteService.Core.Handlers
{
    public class UserHandler :
        IRequestHandler<AddUser, CommandResponse>,
        IRequestHandler<GetAllUser, List<UsersResponse>>,
        IRequestHandler<AddCash, CommandResponse>,
        IRequestHandler<SendValue, CommandResponse>
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<TAccount> _accountRepository;
        private readonly IRepository<TTransfer> _transferRepository;
        public UserHandler(IUserRepository userRepository, IMapper mapper, IRepository<TAccount> accountRepository, IRepository<TTransfer> transferRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _accountRepository = accountRepository;
            _transferRepository = transferRepository;
        }

        public async Task<CommandResponse> Handle(AddUser request, CancellationToken cancellationToken)
        {
            TUser user = await _userRepository.FindByCpf(request.CPF_CNPJ);
            if(user != null)
            {
                return new CommandResponse(false, "CPF JÁ EXISTE");
            }
            TUser typeuser = await _userRepository.FindByEmail(request.TypeUser);
            if (typeuser != null)
            {
                return new CommandResponse(false, "EMAIL JÁ EXISTE");
            }
            TUser email = await _userRepository.FindByEmail(request.Email);
            if (email != null)
            {
                return new CommandResponse(false, "EMAIL JÁ EXISTE");
            }
            try
            {
                ValidationResult result = BaseValidator.Validate(new AddUserValidator(), request);
                if (result.IsValid)
                {
                    TUser entity = _mapper.Map<TUser>(request);
                    await _userRepository.AddAsync(entity);
                    entity.Account = new TAccount()
                    {
                        Cash = 0,
                        UserID = entity.ID
                    };
                    await _accountRepository.AddAsync(entity.Account);
                    return new CommandResponse(result.IsValid, "CADASTRO REALIZADO COM SUCESSO");
                }
                else
                {
                    return new CommandResponse(result.IsValid, "FALHA NA VALIDAÇÃO DO CAMPOS", result.Errors);
                }
            }
            catch
            {
                return new CommandResponse(false, "FALHA NO PROCESSAMENTO DA REQUISIÇÃO");
            }
        }

        public async Task<List<UsersResponse>> Handle(GetAllUser request, CancellationToken cancellationToken)
        {
            var list = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UsersResponse>>(list);
        }

        public async Task<CommandResponse> Handle(AddCash request, CancellationToken cancellationToken)
        {
            TUser user = await _userRepository.FindByCpf(request.CpfCnpj);
            if (user == null)
            {
                return new CommandResponse(false, "CPF NÃO ENCONTRADO");
            }
            user.Account.Cash = user.Account.Cash + request.Value;
            await _accountRepository.UpdateAsync(user.Account);
            return new CommandResponse(true, "OPERAÇÃO REALIZADA COM SUCESSO");
        }

        public async Task<CommandResponse> Handle(SendValue request, CancellationToken cancellationToken)
        {
            TUser send = await _userRepository.FindByCpf(request.CpfCnpjSend);
            if (send == null)
            {
                return new CommandResponse(false, "CPF/CNPJ DO REMETENTE NÃO ENCONTRADO");
            }
            TUser receiver = await _userRepository.FindByCpf(request.CpfCnpjReceive);
            if (receiver == null)
            {
                return new CommandResponse(false, "CPF/CNPJ DO RECEBIDOR NÃO ENCONTRADO");
            }
            if(send.TypeUser == TypeUser.LOJISTA)
            {
                return new CommandResponse(false, "LOJISTAS NÃO PODEM REALIZAR TRANSFERÊNCIA");
            }
            if (send.TypeUser < TypeUser.LOJISTA)
            {
                return new CommandResponse(false, "LOJISTAS NÃO PODEM REALIZAR TRANSFERÊNCIA");
            }
            ValidationResult result = BaseValidator.Validate(new SendValueValidator(), request);
            if (!result.IsValid)
            {
                return new CommandResponse(false, "", result.Errors);
            }
            if (send.Account.Cash < request.Value)
            {
                TTransfer transfer = new TTransfer()
                {
                    Value = request.Value,
                    OperationDate = DateTime.Now,
                    SendID = send.ID,
                    ReceiptID = receiver.ID,
                    OperationStatus = OperationStatus.Fail
                };
                await _transferRepository.AddAsync(transfer);
                return new CommandResponse(false, "SALDO INSUFICIENTE");
            }
            else
            {
                send.Account.Cash = send.Account.Cash - request.Value;
                await _accountRepository.UpdateAsync(send.Account);

                receiver.Account.Cash = receiver.Account.Cash + request.Value;
                await _accountRepository.UpdateAsync(receiver.Account);
                TTransfer transfer = new TTransfer()
                {
                    Value = request.Value,
                    OperationDate = DateTime.Now,
                    SendID = send.ID,
                    ReceiptID = receiver.ID,
                    OperationStatus = OperationStatus.OK

                };
                await _transferRepository.AddAsync(transfer);
               // await SendMail(receiver.Email);
                return new CommandResponse(true, "TRANSFERÊNCIA REALIZADA COM SUCESSO!");
            }
        }

       /* private SendMail(string email)
        {
         //Iplementar aqui o envio de email   
            
        }*/
    }
}
