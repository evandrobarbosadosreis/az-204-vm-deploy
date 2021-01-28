using System;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace az_204_vm_deploy
{
    class Program
    {

        static string ReaderAdminUser()
        {
            Console.Write("Digite o nome do usuário administrador: ");
            return Console.ReadLine();
        }

        static string ReadAdminPassword()
        {
            Console.Write("Digite a senha: ");
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            //autenticação da aplicação
            var credentials = SdkContext.AzureCredentialsFactory.FromFile("./azureauth.properties");

            var azure = Azure.Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                .Authenticate(credentials)
                .WithDefaultSubscription();

            //criando um resource group
            var groupName = "az-204-resource-group";
            var region    = Region.USEast2;

            Console.WriteLine($"Resource Group: {groupName}");
            var resourceGroup = azure.ResourceGroups.Define(groupName)
                .WithRegion(region)
                .Create();

            //criando uma virtual network e uma virtual subnet
            var networkName   = "az-204-virtual-network";
            var networkAdress = "192.0.0.0/16";
            var subnetName    = "az-204-virtual-subnet";
            var subnetAdress  = "192.0.0.0/24";

            Console.WriteLine($"Virtual Network: {networkName}");
            var network = azure.Networks.Define(networkName)
                .WithRegion(region)
                .WithExistingResourceGroup(resourceGroup)
                .WithAddressSpace(networkAdress)
                .WithSubnet(subnetName, subnetAdress)
                .Create();

            //cria um network interface card para conectar a vm na network
            var networkInterfaceName = "az-204-network-interface-card";
            
            Console.WriteLine($"Virtual Network Interface Card: {networkInterfaceName}");
            var networkInterface = azure.NetworkInterfaces.Define(networkInterfaceName)
                .WithRegion(region)
                .WithExistingResourceGroup(resourceGroup)
                .WithExistingPrimaryNetwork(network)
                .WithSubnet(subnetName)
                .WithPrimaryPrivateIPAddressDynamic()
                .Create();

            //cria a máquina virtual
            var virtualMachineName = "az-204-vm";
            var adminUser     = ReaderAdminUser();
            var adminPassword = ReadAdminPassword();

            Console.WriteLine($"Virtual Machine: {virtualMachineName}");
            var virtualMachine = azure.VirtualMachines.Define(virtualMachineName)
                .WithRegion(region)
                .WithExistingResourceGroup(resourceGroup)
                .WithExistingPrimaryNetworkInterface(networkInterface)
                .WithLatestWindowsImage("MicrosoftWindowsServer", "WindowsServer", "2019-Datacenter")
                .WithAdminUsername(adminUser)
                .WithAdminPassword(adminPassword)
                .WithComputerName(virtualMachineName)
                .WithSize(VirtualMachineSizeTypes.StandardDS2V2)
                .Create();

            Console.WriteLine("Processo concluído");
        }
    }
}
