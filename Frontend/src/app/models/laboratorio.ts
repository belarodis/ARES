import { ReservaLaboratorio } from "./reserva-laboratorio";

export interface Laboratorio {
  id: number;
  nome: string;
  qtdComputadores: number;
  configComputadores: string;
  reservasLaboratorio?: ReservaLaboratorio[];
}
