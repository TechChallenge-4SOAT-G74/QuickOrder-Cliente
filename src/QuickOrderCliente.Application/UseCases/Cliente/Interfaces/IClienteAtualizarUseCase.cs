﻿using QuickOrderCliente.Application.Dtos;

namespace QuickOrderCliente.Application.UseCases.Cliente.Interfaces
{
    public interface IClienteAtualizarUseCase
    {
        Task<ServiceResult> Execute(ClienteDto produto, int id);
    }
}