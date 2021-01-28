# AZ-204 Virtual Machine Deploy

Exercício realizado como preparação para o exame AZ-204 demonstrando o processo de configuração e deploy de uma VM por meio do SDK da plataforma Azure.

Através deste exemplo, é possível compreender melhor a relação e quais são os recursos necessários para realizar um deploy de VM em ambiente de núvem.

Os recursos criados neste exemplo são:

- Resource Group;
- Virtual Network
- Virtual Network Subnet
- Virtual Network Interface Card
- Virtual Machine

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

Para que o aplicativo se conecte corretamente em sua conta algumas informações são necessárias no arquivo `azureauth.properties`, sendo:

- subscription-id: Pode ser recuperado no menu de "Subscriptions"
- tenant-id: Obtido no menu "Azure Active Directory" > "Properties"
- cliend-id: O client-id é gerado após registrar seu aplicativo na opção "Azure Active Directory" -> "App registrations"
- client-secret: Após liberar o aplicativo e obter o client-id, gere uma chave de acesso no menu "Certificates & secrets"

Após isso, crie uma "Role Assignment" como "Contribuitor" para o seu aplicativo no menu "Access Control" da sua Subscription.
