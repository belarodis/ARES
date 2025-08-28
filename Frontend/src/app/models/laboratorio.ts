import { ReservaLaboratorio } from "./reserva-laboratorio";

export interface Funcionario {
  id: number;
  nome: string;
  qtdComputadores: number;
  configComputadores: string;
  reservasLaboratorio?: ReservaLaboratorio[];
}
