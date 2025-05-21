import { HttpException, HttpStatus, Injectable } from '@nestjs/common';
import { FindAllParameters } from 'src/cliente/cliente.dto';
import { ClienteDto } from './cliente.dto';

@Injectable()
export class ClienteService {
  private clientes: ClienteDto[] = [];

  create(cliente: ClienteDto) {
    this.clientes.push(cliente);
    console.log('Cliente criado:', this.clientes);
  }

  findById(id: string): ClienteDto {
    const foundCliente = this.clientes.filter((p) => p.id === id);

    if (foundCliente.length) {
      return foundCliente[0];
    }
    throw new HttpException(
      `Cliente with ID ${id} not found`,
      HttpStatus.NOT_FOUND,
    );
  }

  findAll(paramns: FindAllParameters): ClienteDto[] {
    const { nome, cpf, cnpj, razaoSocial } = paramns;

    return this.clientes.filter((cliente) => {
      return (
        (nome ? cliente.nome.includes(nome) : true) &&
        (cpf ? cliente.cpf.includes(cpf) : true) &&
        (cnpj ? cliente.cnpj.includes(cnpj) : true) &&
        (razaoSocial ? cliente.razaoSocial.includes(razaoSocial) : true)
      );
    });
  }

  update(cliente: ClienteDto) {
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
