# Quick Order - Tech Challenge FIAP

Projeto do Tech Challenge da FIAP - Fase 5

**INTEGRANTES DO GRUPO 74**

* Moisés Barboza de Figueiredo Junior
moises.figueiredo@gmail.com

* Gabriela da Silva Lopes
gabrieladslopes@gmail.com

* Francisco Tadeu da Silva e Souza
fsouza.thadeu@gmail.com

<br />

<br />

## Microserviço - Cliente
Microserviço de pedido é usado para organizar os dados pessoais do Cliente; permitindo Cadastrar, Listar, Atualizar, Excluir ou Inativar seus dados.


<br />

## Pré-Requisitos

Antes de executar este projeto, os seguintes itens deverão estar instalados no computador:

* Docker
* Kubernetes


<br />

Passo a passo - Instalação:

* Obter os scripts de instalação do kubernetes no repositório https://github.com/TechChallenge-4SOAT-G74/QuickOrder-Infra-MicroServices-Kubernetes

* Abrir alguma interface de linha de comando como, por exemplo, o **PowerShell** e digitar o comando `kubectl config get-contexts`. O resultado deverá ser conforme abaixo, com o contexto do **docker-desktop** selecionado:
  
<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/ce7f5145-2ae7-44a0-82d5-fecf3c593589)


* Caso o contexto do **docker-desktop** não esteja selecionado, selecionar o mesmo através do comando `kubectl config set-context docker-desktop`
* Executar o comando `kubectl get all` para garantir que o cluster esteja limpo e assim prevenir que ocorram conflitos de portas nos passos posteriores. O resultado deverá ser esse:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/01637947-6284-4dd3-a148-d1cc039603f4)


<br />

* Caso haja algum **pod, svc ou deployment** etc listado no passo anterior, limpar o cluster através do comando `kubectl delete all --all` e `kubectl delete pvc --all`
* Baixe o projeto QuickOrder-Infra-Kubernetes do repositório https://github.com/TechChallenge-4SOAT-G74/QuickOrder-Infra-MicroServices-Kubernetes.git
* Verifique os sprits do repositório digitando `ls` 

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-Produto/assets/19378661/83153e7a-811c-4eb0-9f7b-da3590a2e99a)



<br />
