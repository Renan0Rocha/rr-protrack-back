import {
  Body,
  Controller,
  Delete,
  Get,
  Param,
  Post,
  Put,
  Query,
} from '@nestjs/common';
import { FindAllParameters } from 'src/cliente/cliente.dto';
import { ClienteDto } from './cliente.dto';
import { ClienteService } from './cliente.service';

@Controller('cliente')
export class ClienteController {
  constructor(private readonly clienteService: ClienteService) {}
  @Post()
  create(@Body() cliente: ClienteDto) {
    this.clienteService.create(cliente);
  }

  @Get('/:id')
  findById(@Param('id') id: string): ClienteDto {
    return this.clienteService.findById(id);
  }

  @Get()
  findAll(@Query() params: FindAllParameters): ClienteDto[] {
    return this.clienteService.findAll(params);
  }

  @Put('/:id')
  update(@Body() cliente: ClienteDto) {
    this.clienteService.update(cliente);
  }

  @Delete('/:id')
  remove(@Param('id') id: string) {
    return this.clienteService.remove(id);
  }
}
