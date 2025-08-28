import { ReservaNotebook } from "./reserva-notebook";

export interface Notebook{
    id: number;
    nPatrimonio: string;
    dataAquisicao: Date;
    descricao: string;
    reservasNotebook?: ReservaNotebook[]; 
}