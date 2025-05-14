export class ProgramaDto {
  id: string;
  nome: string;
  sigla: string;
  descricao: string;
  tipo: string;
  horarioInicio: Date;
  horarioFim: Date;
  dataInicio: Date;
  dataFim: Date;
  status: string;
  createdAt: Date;
  updatedAt: Date;
}

export interface FindAllParameters {
  nome: string;
  sigla: string;
  descricao: string;
  tipo: string;
  horarioInicio: Date;
  horarioFim: Date;
}
