export interface Funcionario {
  id: number;
  matricula: string;
  nome: string;
  cargo: string;
  dataAdmissao: Date;
  reservasLaboratorio?: any[]; // Substitua 'any' pelo tipo correto se criar o model ReservaLaboratorio
  reservasNotebook?: any[]; // Substitua 'any' pelo tipo correto se criar o model ReservaNotebook
  reservasSala?: any[]; // Substitua 'any' pelo tipo correto se criar o model ReservaSala
}
