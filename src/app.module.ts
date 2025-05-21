import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { ClienteModule } from './cliente/cliente.module';
import { ProgramaModule } from './programa/programa.module';

@Module({
  imports: [ProgramaModule, ClienteModule],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
