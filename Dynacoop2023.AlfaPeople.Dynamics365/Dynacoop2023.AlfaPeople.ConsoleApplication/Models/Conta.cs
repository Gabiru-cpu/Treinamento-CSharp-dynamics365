using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynacoop2023.AlfaPeople.ConsoleApplication.Models
{
    public class Conta
    {
        public CrmServiceClient ServiceClient { get; set; }

        public string Logicalname { get; set; }

        public Conta(CrmServiceClient crmServiceClient) 
        {
            this.ServiceClient = crmServiceClient;
            this.Logicalname= "account";
        }
        public Guid Create()
        {
            Entity conta = new Entity(this.Logicalname);
            conta["name"] = "Volkswagen";
            conta["telephone1"] = "(11) 1515-3232";
            conta["fax"] = "(11) 1515-3232";

            conta["dcp_nmr_total_opp"] = 12;
            conta["dcp_tipoderelacao"] = new OptionSetValue(775050001);
            conta["dcp_valor_total_opp"] = new Money(150);
            conta["primarycontactid"] = new EntityReference("contact", new Guid("79ae8582-84bb-ea11-a812-000d3a8b3ec6"));

            Guid accountId = this.ServiceClient.Create(conta);
            return accountId;
        }

        public bool Update(Guid accountId, string telephone1) 
        {
            try 
            {
                Entity conta = new Entity(this.Logicalname, accountId);
                conta["telephone1"] = telephone1;
                this.ServiceClient.Update(conta);
                return true;
            }
            catch (Exception ex) 
            {           
                Console.WriteLine(ex.ToString());
                return false;
            }
            
        }

        public bool Delete(Guid accountId) 
        {
            try 
            {
                this.ServiceClient.Delete(this.Logicalname, accountId);
                return true;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
