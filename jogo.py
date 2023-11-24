from tabuleiro import Tabuleiro
from navio import Navio
class Jogo:
    def __init__(self):
        self.tabuleiro = Tabuleiro()
        self.navios = [Navio('P', 5), Navio('C', 4), Navio('T', 3), Navio('R', 2), Navio('R', 2), Navio('R', 2)]
        self.vidas = 5

    def iniciar(self):
        self.posicionar_navios()
        while True:
            self.tabuleiro.exibir()
            print(f"Vidas: {self.vidas}")            
            linha = int(input("Informe a linha (0-9): "))
            coluna = input("Informe a coluna (A-J): ")

            if not self.tabuleiro.validar_tiro(linha, coluna):
                print("\nTiro inválido. Tente novamente.\n")
                continue

            self.fazer_tiro(linha, coluna)

            if self.tabuleiro.verificar_vitoria():
                self.tabuleiro.exibir()
                print("Você é o Vencedor! Parabéns!")
                break

            if self.vidas == 0:
                self.tabuleiro.exibir()
                print("Precisa treinar mais. Você perdeu!")
                break

    def posicionar_navios(self):
        for navio in self.navios:
            navio.posicionar(self.tabuleiro)

    def fazer_tiro(self, linha, coluna):
        for navio in self.navios:
            if navio.verificar_tiro(linha, coluna):
                if navio.pontos_atingidos == 0:
                    print(f"Você acertou uma parte do navio {navio.tipo}!")
                elif navio.pontos_atingidos == navio.tamanho - 1:
                    print(f"Você acertou a última parte do navio {navio.tipo} e o afundou!")
                else:
                    print(f"Você acertou mais uma parte do navio {navio.tipo}!")
                navio.pontos_atingidos += 1
                self.tabuleiro.atualizar(linha, coluna, navio.tipo)
                return

        self.tabuleiro.atualizar(linha, coluna, 'X')