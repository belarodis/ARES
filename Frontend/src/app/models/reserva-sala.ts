export interface ReservaSala{
    id: number;
    fkFuncionario: number;
    fkSala: number;
    dataReserva: Date;
    nomeFuncionario: string;
    numeroSala: string;
}