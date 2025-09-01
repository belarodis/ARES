import { ReservaLaboratorio } from "./reserva-laboratorio";
import { ReservaNotebook } from "./reserva-notebook";
import { ReservaSala } from "./reserva-sala";

export interface Funcionario {
  id: number;
  matricula: string;
  nome: string;
  cargo: string;
  dataAdmissao: Date;
  reservasLaboratorio?: ReservaLaboratorio[];
  reservasNotebook?: ReservaNotebook[];
  reservasSala?: ReservaSala[];
}
