import random

class Navio:
    def __init__(self, tipo, tamanho):
        self.tipo = tipo
        self.tamanho = tamanho
        self.orientacao = None
        self.posicao = None

    def posicionar(self, tabuleiro):
        while True:
            x = random.randint(0, tabuleiro.tamanho - 1)
            y = random.randint(0, tabuleiro.tamanho - 1)
            orientacao = random.choice(['horizontal', 'vertical'])

            if self.validar_posicao(tabuleiro, x, y, orientacao):
                self.orientacao = orientacao
                self.posicao = (x, y)
                self.marcar_posicao(tabuleiro, x, y)
                break

    def validar_posicao(self, tabuleiro, x, y, orientacao):
        if orientacao == 'horizontal':
            if y + self.tamanho > tabuleiro.tamanho:
                return False
            for i in range(self.tamanho):
                if tabuleiro.matriz[x][y + i] != ' ':
                    return False
        else:
            if x + self.tamanho > tabuleiro.tamanho:
                return False
            for i in range(self.tamanho):
                if tabuleiro.matriz[x + i][y] != ' ':
                    return False

        return True

    def marcar_posicao(self, tabuleiro, x, y):
        if self.orientacao == 'horizontal':
            for i in range(self.tamanho):
                tabuleiro.matriz[x][y + i] = self.tipo
        else:
            for i in range(self.tamanho):
                tabuleiro.matriz[x + i][y] = self.tipo