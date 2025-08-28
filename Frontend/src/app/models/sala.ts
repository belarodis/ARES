import { ReservaSala } from "./reserva-sala";

export interface Sala{
    id: number;
    numeroSala: string;
    temProjetor: boolean;
    reservasSala?: ReservaSala[];
}