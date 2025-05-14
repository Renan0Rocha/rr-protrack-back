import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { ProgramaModule } from './programa/programa.module';
import { ClienteModule } from './Cliente/cliente.module';

@Module({
  imports: [ProgramaModule, ClienteModule],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
