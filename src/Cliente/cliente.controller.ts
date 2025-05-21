import {
  Body,
  Controller,
  Delete,
  Get,
  Param,
  Post,
  Put,
} from '@nestjs/common';
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

  @Put('/:id')
  update(@Body() cliente: ClienteDto) {
    this.clienteService.update(cliente);
  }

  @Delete('/:id')
  remove(@Param('id') id: string) {
    return this.clienteService.remove(id);
  }
}
