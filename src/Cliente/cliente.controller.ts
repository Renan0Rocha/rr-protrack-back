import {
  Controller,
  Delete,
  Post,
  Body,
  Get,
  Param,
  Put,
} from '@nestjs/common';
import { clienteDto } from './cliente.dto';
import { ClienteService } from './cliente.service';

@Controller('cliente')
export class ClienteController {
  constructor(private readonly clienteService: ClienteService) {}
  @Post()
  create(@Body() cliente: clienteDto) {
    this.clienteService.create(cliente);
  }

  @Get('/:id')
  findById(@Param('id') id: string): clienteDto {
    return this.clienteService.findById(id);
  }

  @Put('/:id')
  update(@Body() cliente: clienteDto) {
    this.clienteService.update(cliente);
  }

  @Delete('/:id')
  remove(@Param('id') id: string) {
    return this.clienteService.remove(id);
  }
}
