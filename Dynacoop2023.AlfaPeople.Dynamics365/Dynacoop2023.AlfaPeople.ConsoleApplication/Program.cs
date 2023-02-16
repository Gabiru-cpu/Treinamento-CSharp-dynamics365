using Dynacoop2023.AlfaPeople.ConsoleApplication.Controllers;
using Dynacoop2023.AlfaPeople.ConsoleApplication.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Dynacoop2023.AlfaPeople.ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CrmServiceClient serviceClient = Singleton.GetService();

            ContaController contaController = new ContaController(serviceClient);

            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("Digite 1 para Create/Update");
            Console.WriteLine("Digite 2 para Delete");

            var answerWhatToDo = Console.ReadLine();

            if (answerWhatToDo.ToString() == "1")
                MakeCreateAndUpdate(contaController);
            else
            {
                if (answerWhatToDo.ToString() == "2")
                {
                    MakeDelete(contaController);
                }
                else 
                { 
                    Console.WriteLine("Opção inválida reinicie o app");
                }
            }

            Console.ReadKey();
        }

        private static void MakeDelete(ContaController contaController)
        {
            Console.WriteLine("Digite o id da conta que voce quer deletar");
            var accountId = Console.ReadLine();
            contaController.Delete(new Guid(accountId));
            Console.WriteLine("Conta deletada com sucesso");
        }

        private static void MakeCreateAndUpdate(ContaController contaController)
        {
            Console.WriteLine("Nova conta sendo criada");
            Guid accountId = contaController.Create();
            Console.WriteLine("Conta craida com sucesso");

            Console.WriteLine($"https://org90caa978.crm2.dynamics.com/main.aspx?appid=4d306bb3-f4a9-ed11-9885-000d3a888f48&pagetype=entityrecord&etn=account&id={accountId}");


            Console.WriteLine("Deseja atualizar a conta recém criada S/N");
            var answerToUpdate = Console.ReadLine();

            if (answerToUpdate.ToString().ToUpper() == "S")
            {
                Console.WriteLine("Por favor informe o novo telefone");
                var newTelephone = Console.ReadLine();

                bool contaAtualizada = contaController.Update(accountId, newTelephone);

                if (contaAtualizada)
                    Console.WriteLine("Conta atualizada com sucesso");
                else
                    Console.WriteLine("Erro ao atualizar conta");
            }
        }
    }
}