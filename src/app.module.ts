import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { ClienteModule } from './cliente/cliente.module';
import { ProgramaModule } from './programa/programa.module';
import { UsersModule } from './users/users.module';

@Module({
  imports: [ProgramaModule, ClienteModule, UsersModule],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
