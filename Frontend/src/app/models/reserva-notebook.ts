export interface ReservaNotebook{
    id: number;
    fkFuncionario: number;
    fkNotebook: number;
    dataReserva: Date;
    nomeFuncionario: string;
    nomeNotebook: string;
}