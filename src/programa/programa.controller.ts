import {
  Body,
  Controller,
  Delete,
  Get,
  Param,
  Post,
  Put,
} from '@nestjs/common';
import { ProgramaDto } from './programa.dto';
import { ProgramaService } from './programa.service';

@Controller('programa')
export class ProgramaController {
  constructor(private readonly programaService: ProgramaService) {}

  @Post()
  create(@Body() programa: ProgramaDto) {
    this.programaService.create(programa);
  }

  @Get('/:id')
  findById(@Param('id') id: string): ProgramaDto {
    return this.programaService.findById(id);
  }

  @Put('/:id')
  update(@Body() programa: ProgramaDto) {
    this.programaService.update(programa);
  }

  @Delete('/:id')
  remove(@Param('id') id: string) {
    return this.programaService.remove(id);
  }
}
