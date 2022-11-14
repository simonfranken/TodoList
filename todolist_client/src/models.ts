export interface route {
  path: string;
  component: any;
  key: string;
  icon: string;
  displayName: string;
}

export interface TodoEntry {
  entryId?: string;
  name: string;
  description: string;
  done: boolean;
}
