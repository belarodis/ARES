export interface ReservaLaboratorio{
    id: number;
    fkFuncionario: number;
    fkLaboratorio: number;
    dataReserva: Date;
}