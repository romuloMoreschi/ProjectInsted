import random

# Constantes
TamanhoDoTabuleiro = 10
VidasIniciais = 5
Direcoes = [(0, 1), (1, 0)]  # horizontal, vertical
NaviosTamanho = {'P': 5, 'C': 4, 'T': 3, 'R': 2}
NaviosTotal = {'P': 1, 'C': 1, 'T': 2, 'R': 3}

# Mapeia letras para números (A-J)
coluna_letra_para_numero = {'A': 0, 'B': 1, 'C': 2, 'D': 3, 'E': 4, 'F': 5, 'G': 6, 'H': 7, 'I': 8, 'J': 9}

# Função para criar o tabuleiro com os navios
def criarTabuleiroNavios():
    return [[' ' for _ in range(TamanhoDoTabuleiro)] for _ in range(TamanhoDoTabuleiro)]

# Função para criar o tabuleiro vazio
def criarTabuleiroVazio():
    return [[' ' for _ in range(TamanhoDoTabuleiro)] for _ in range(TamanhoDoTabuleiro)]

# Função para imprimir o tabuleiro
def imprimirTabuleiro(tabuleiro):
    print("  A B C D E F G H I J")
    for i in range(TamanhoDoTabuleiro):
        linhaExibicao = [str(i)]  # Adiciona o número da linha
        for j in range(TamanhoDoTabuleiro):
            linhaExibicao.append(tabuleiro[i][j])
        print(' '.join(linhaExibicao))

# Função para verificar se uma posição está vazia e não se choca com outros navios
def posicaoValida(tabuleiro, linha, coluna, tamanho, direcao):
    for i in range(tamanho):
        novaLinha = linha + i * direcao[0]
        novaColuna = coluna + i * direcao[1]

        if (
            novaLinha < 0
            or novaLinha >= TamanhoDoTabuleiro
            or novaColuna < 0
            or novaColuna >= TamanhoDoTabuleiro
            or tabuleiro[novaLinha][novaColuna] != ' '
        ):
            return False

    # Verifica se as posições adjacentes estão vazias
    for i in range(tamanho):
        novaLinha = linha + i * direcao[0]
        novaColuna = coluna + i * direcao[1]

        for linhaAdjacente in range(novaLinha - 1, novaLinha + 2):
            for colunaAdjacente in range(novaColuna - 1, novaColuna + 2):
                if (
                    0 <= linhaAdjacente < TamanhoDoTabuleiro
                    and 0 <= colunaAdjacente < TamanhoDoTabuleiro
                    and tabuleiro[linhaAdjacente][colunaAdjacente] != ' '
                ):
                    return False

    return True

# Função para posicionar os navios no tabuleiro
def posicionarNavios(tabuleiro):
    for navio, quantidade in NaviosTotal.items():
        for _ in range(quantidade):
            tentativas = 0
            while tentativas < 10:  # Limite o número de tentativas para evitar loops infinitos
                tentativas += 1
                direcao = random.choice(Direcoes)
                linha = random.randint(0, TamanhoDoTabuleiro - 1)
                coluna = random.randint(0, TamanhoDoTabuleiro - 1)

                # Verifica se é possível posicionar o navio naquela direção
                if posicaoValida(tabuleiro, linha, coluna, NaviosTamanho[navio], direcao):
                    for i in range(NaviosTamanho[navio]):
                        novaLinha = linha + i * direcao[0]
                        novaColuna = coluna + i * direcao[1]
                        tabuleiro[novaLinha][novaColuna] = navio
                    break

# Função para verificar se o jogador acertou um navio
def verificarTiro(tabuleiroNavios, tabuleiroTiros, linha, coluna, mostrarNavios):
    if tabuleiroNavios[linha][coluna] != ' ' and tabuleiroTiros[linha][coluna] != 'X':
        navio = tabuleiroNavios[linha][coluna]
        tabuleiroTiros[linha][coluna] = navio  # Marcar como atingido
        if mostrarNavios:            
            imprimirTabuleiro(tabuleiroNavios)  # Imprimir o tabuleiro após o acerto
        else:
            imprimirTabuleiro(tabuleiroTiros)  # Imprimir o tabuleiro após o acerto

        print(f"\nAcertou um navio: {navio}")

        return navio
    else:
        # Adiciona marcação para indicar tiro na água
        tabuleiroTiros[linha][coluna] = 'X'

        print("\nÁgua! Você errou o tiro.\n")

        if mostrarNavios:            
            imprimirTabuleiro(tabuleiroNavios)  # Imprimir o tabuleiro após o erro
        else:
            imprimirTabuleiro(tabuleiroTiros)  # Imprimir o tabuleiro após o erro
        return None    

# Função principal do jogo
def jogar(mostrarNavios=True):
    tabuleiroNavios = criarTabuleiroNavios()
    tabuleiroTiros = criarTabuleiroVazio()

    posicionarNavios(tabuleiroNavios)

    vidas = VidasIniciais
    tirosConsecutivos = 0

    if mostrarNavios:
        imprimirTabuleiro(tabuleiroNavios)
    else:
        imprimirTabuleiro(tabuleiroTiros)

    while vidas > 0:
        print(f"\nVidas restantes: {vidas}")

        linha = int(input("\nDigite a linha do tiro (0-9): "))
        coluna_letra = input("Digite a coluna do tiro (A-J): ")

        # Converte a letra da coluna para o número correspondente
        coluna = coluna_letra_para_numero.get(coluna_letra.upper())

        resultadoTiro = verificarTiro(tabuleiroNavios, tabuleiroTiros, linha, coluna, mostrarNavios)

        if resultadoTiro:
            tirosConsecutivos += 1
            if tirosConsecutivos == 3:
                vidas += 1
                tirosConsecutivos = 0
        else:            
            vidas -= 1
            tirosConsecutivos = 0

        # Verifica se todos os navios foram abatidos
        naviosRestantes = sum(
            tabuleiroNavios[i].count('P') + tabuleiroNavios[i].count('C') + tabuleiroNavios[i].count('T') +
            tabuleiroNavios[i].count('R')
            for i in range(TamanhoDoTabuleiro))
        if naviosRestantes == 0:
            print("\nParabéns! Você abateu todos os navios. Você é o Vencedor!")
            break

    if vidas == 0:
        print("\nSuas vidas acabaram. Você precisa treinar mais.")

jogar()