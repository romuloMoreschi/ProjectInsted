class Tabuleiro:
    def __init__(self):
        self.tamanho = 10
        self.matriz = [[' ' for _ in range(self.tamanho)] for _ in range(self.tamanho)]

    def esconder_navios(self):
        for linha in self.matriz:
            for i in range(self.tamanho):
                if linha[i] != 'X':
                    linha[i] = ' '

    def exibir(self):
        self.esconder_navios()
        print("  A B C D E F G H I J")
        for i in range(self.tamanho):
            print(i, ' '.join(self.matriz[i]))

    def validar_tiro(self, linha, coluna_str):
        coluna_idx = ord(coluna_str) - ord('A')
        if linha < 0 or linha >= self.tamanho or coluna_idx < 0 or coluna_idx >= self.tamanho:
            return False
        return True

    def atualizar(self, linha, coluna, valor):
        self.matriz[linha][ord(coluna) - ord('A')] = valor

    def verificar_vitoria(self):
        for linha in self.matriz:
            for coluna in linha:
                if coluna in 'PCRT':
                    return False
        return True