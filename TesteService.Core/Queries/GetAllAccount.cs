using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TesteService.Core.Responses;

namespace TesteService.Core.Queries
{
    public class GetAllAccount : IRequest<List<AccountResponse>>
    {
    }
}