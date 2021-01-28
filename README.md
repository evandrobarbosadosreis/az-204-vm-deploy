# AZ-204 Virtual Machine Deploy

Exercício realizado como preparação para o exame AZ-204 demonstrando o processo de configuração e deploy de uma VM por meio do SDK da plataforma Azure.

Através deste exemplo, é possível compreender melhor a relação e quais são os recursos necessários para realizar um deploy de uma VM em ambiente de núvem.

Os recursos criados neste exemplo são:

- Resource Group
- Virtual Network
- Virtual Network Subnet
- Virtual Network Interface Card
- Virtual Machine
- Public IP Address 
- Network Security Group

Além destes recursos, será criado automaticamente um Virtual Disk. 

## Instalação do SDK

Comando de instalação do pacote: `dotnet add package Microsoft.Azure.Management.Fluent`

## Listagem dos Sistemas Operacionais do Azure Marketplace

Para definir o Sistema Operacional da VM são informados 3 parâmetros:

- Publisher
- Offer
- SKU

É possível obter essas informações utilizando o Azure CLI:

`az login`

`az vm image list`

## Configurando o aplicativo

Para saber como configurar o acesso do seu aplicativo aos serviços da azure, clique [https://docs.microsoft.com/en-us/azure/active-directory/develop/howto-create-service-principal-portal](aqui).
