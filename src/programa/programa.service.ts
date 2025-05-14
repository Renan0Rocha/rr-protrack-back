import { HttpException, HttpStatus, Injectable } from '@nestjs/common';
import { FindAllParameters, ProgramaDto } from './programa.dto';

@Injectable()
export class ProgramaService {
  private programas: ProgramaDto[] = [];

  create(programa: ProgramaDto) {
    this.programas.push(programa);
    console.log('Programa criado:', this.programas);
  }

  findById(id: string): ProgramaDto {
    const foundProgrma = this.programas.filter((p) => p.id === id);

    if (foundProgrma.length) {
      return foundProgrma[0];
    }
    throw new HttpException(
      `Programa with ID ${id} not found`,
      HttpStatus.NOT_FOUND,
    );
  }

  findAll(paramns: FindAllParameters): ProgramaDto[] {
    const { nome, sigla } = paramns;

    return this.programas.filter((programa) => {
      return (
        (nome ? programa.nome.includes(nome) : true) &&
        (sigla ? programa.sigla.includes(sigla) : true)
      );
    });
  }

  update(programa: ProgramaDto) {
    const programaIndex = this.programas.findIndex((p) => p.id === programa.id);

    if (programaIndex >= 0) {
      this.programas[programaIndex] = programa;
      return;
    }
    throw new HttpException(
      `Programa with ID ${programa.id} not found`,
      HttpStatus.BAD_REQUEST,
    );
  }

  remove(id: string) {
    const programaIndex = this.programas.findIndex((p) => p.id === id);

    if (programaIndex >= 0) {
      this.programas.splice(programaIndex, 1);
      return;
    }
    throw new HttpException(
      `Programa with ID ${id} not found`,
      HttpStatus.BAD_REQUEST,
    );
  }
}
