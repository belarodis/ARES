// Tipos de recurso possíveis (mesmo que tu já tenha entidades separadas)
export type TipoRecurso = 'NOTEBOOK' | 'SALA' | 'LABORATORIO';

// Resumo de um dia (o que o back retorna já agregado)
export interface DiaResumo {
  /** formato 'YYYY-MM-DD' */
  date: string;
  total: number;
  porTipo: Partial<Record<TipoRecurso, number>>;
}

// Célula do calendário (cada quadradinho do mês)
export interface DiaCell {
  iso: string; // 'YYYY-MM-DD'
  inMonth: boolean; // se pertence ao mês atual
  isToday: boolean;
  resumo?: DiaResumo; // opcional, só vem quando o back manda dados
}
