import { HttpException, HttpStatus, Injectable } from '@nestjs/common';
import { clienteDto } from './cliente.dto';

@Injectable()
export class ClienteService {
  private clientes: clienteDto[] = [];

  create(cliente: clienteDto) {
    this.clientes.push(cliente);
    console.log('Cliente criado:', this.clientes);
  }

  findById(id: string): clienteDto {
    const foundCliente = this.clientes.filter((p) => p.id === id);

    if (foundCliente.length) {
      return foundCliente[0];
    }
    throw new HttpException(
      `Cliente with ID ${id} not found`,
      HttpStatus.NOT_FOUND,
    );
  }

  update(cliente: clienteDto) {
    const clienteIndex = this.clientes.findIndex((p) => p.id === cliente.id);

    if (clienteIndex >= 0) {
      this.clientes[clienteIndex] = cliente;
      return;
    }
    throw new HttpException(
      `Cliente with ID ${cliente.id} not found`,
      HttpStatus.BAD_REQUEST,
    );
  }

  remove(id: string) {
    const clienteIndex = this.clientes.findIndex((p) => p.id === id);

    if (clienteIndex >= 0) {
      this.clientes.splice(clienteIndex, 1);
      return;
    }
    throw new HttpException(
      `Cliente with ID ${id} not found`,
      HttpStatus.BAD_REQUEST,
    );
  }
}
