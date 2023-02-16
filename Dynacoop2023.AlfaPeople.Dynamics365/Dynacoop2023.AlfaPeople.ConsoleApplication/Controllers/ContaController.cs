using Dynacoop2023.AlfaPeople.ConsoleApplication.Models;
using Microsoft.Rest;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynacoop2023.AlfaPeople.ConsoleApplication.Controllers
{
    public class ContaController
    {
        public CrmServiceClient ServiceClient { get; set; }
        public Conta Conta { get; set; }

        public ContaController(CrmServiceClient crmServiceCliente)
        {
            ServiceClient = crmServiceCliente;
            this.Conta = new Conta(ServiceClient);
        }

        public Guid Create()
        {
            return Conta.Create();
        }

        public bool Update(Guid accountId, string telephone1) 
        {
            return Conta.Update(accountId, telephone1);
        }

        public bool Delete(Guid accountId) 
        { 
            return Conta.Delete(accountId);
        }
    }
}
