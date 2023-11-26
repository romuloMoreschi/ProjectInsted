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
def criar_tabuleiro_navios():
    return [[' ' for _ in range(TamanhoDoTabuleiro)] for _ in range(TamanhoDoTabuleiro)]

# Função para criar o tabuleiro vazio
def criar_tabuleiro_vazio():
    return [[' ' for _ in range(TamanhoDoTabuleiro)] for _ in range(TamanhoDoTabuleiro)]

# Função para imprimir o tabuleiro
def imprimir_tabuleiro(tabuleiro):
    print("  A B C D E F G H I J")
    for i in range(TamanhoDoTabuleiro):
        linha_exibicao = [str(i)]  # Adiciona o número da linha
        for j in range(TamanhoDoTabuleiro):
            linha_exibicao.append(tabuleiro[i][j])
        print(' '.join(linha_exibicao))

# Função para verificar se uma posição está vazia e não se choca com outros navios
def posicao_valida(tabuleiro, linha, coluna, tamanho, direcao):
    for i in range(tamanho):
        nova_linha = linha + i * direcao[0]
        nova_coluna = coluna + i * direcao[1]

        if (
            nova_linha < 0
            or nova_linha >= TamanhoDoTabuleiro
            or nova_coluna < 0
            or nova_coluna >= TamanhoDoTabuleiro
            or tabuleiro[nova_linha][nova_coluna] != ' '
        ):
            return False

    # Verifica se as posições adjacentes estão vazias
    for i in range(tamanho):
        nova_linha = linha + i * direcao[0]
        nova_coluna = coluna + i * direcao[1]

        for adjacente_linha in range(nova_linha - 1, nova_linha + 2):
            for adjacente_coluna in range(nova_coluna - 1, nova_coluna + 2):
                if (
                    0 <= adjacente_linha < TamanhoDoTabuleiro
                    and 0 <= adjacente_coluna < TamanhoDoTabuleiro
                    and tabuleiro[adjacente_linha][adjacente_coluna] != ' '
                ):
                    return False

    return True

# Função para posicionar os navios no tabuleiro
def posicionar_navios(tabuleiro):
    for navio, quantidade in NaviosTotal.items():
        for _ in range(quantidade):
            tentativas = 0
            while tentativas < 10:  # Limite o número de tentativas para evitar loops infinitos
                tentativas += 1
                direcao = random.choice(Direcoes)
                linha = random.randint(0, TamanhoDoTabuleiro - 1)
                coluna = random.randint(0, TamanhoDoTabuleiro - 1)

                # Verifica se é possível posicionar o navio naquela direção
                if posicao_valida(tabuleiro, linha, coluna, NaviosTamanho[navio], direcao):
                    for i in range(NaviosTamanho[navio]):
                        nova_linha = linha + i * direcao[0]
                        nova_coluna = coluna + i * direcao[1]
                        tabuleiro[nova_linha][nova_coluna] = navio
                    break

# Função para verificar se o jogador acertou um navio
def verificar_tiro(tabuleiro_navios, tabuleiro_tiros, linha, coluna, mostrar_navios):
    if tabuleiro_navios[linha][coluna] != ' ' and tabuleiro_tiros[linha][coluna] != 'X':
        navio = tabuleiro_navios[linha][coluna]
        tabuleiro_tiros[linha][coluna] = navio  # Marcar como atingido
        if mostrar_navios:            
            imprimir_tabuleiro(tabuleiro_navios)  # Imprimir o tabuleiro após o acerto
        else:
            imprimir_tabuleiro(tabuleiro_tiros)  # Imprimir o tabuleiro após o acerto

        print(f"\nAcertou um navio: {navio}")

        return navio
    else:
        # Adiciona marcação para indicar tiro na água
        tabuleiro_tiros[linha][coluna] = 'X'

        print("\nÁgua! Você errou o tiro.\n")

        if mostrar_navios:            
            imprimir_tabuleiro(tabuleiro_navios)  # Imprimir o tabuleiro após o acerto
        else:
            imprimir_tabuleiro(tabuleiro_tiros)  # Imprimir o tabuleiro após o erro
        return None    

# Função principal do jogo
def jogo_batalha_naval(mostrar_navios=True):
    tabuleiro_navios = criar_tabuleiro_navios()
    tabuleiro_tiros = criar_tabuleiro_vazio()

    posicionar_navios(tabuleiro_navios)

    vidas = VidasIniciais
    tiros_consecutivos = 0

    if mostrar_navios:
        imprimir_tabuleiro(tabuleiro_navios)
    else:
        imprimir_tabuleiro(tabuleiro_tiros)

    while vidas > 0:
        print(f"\nVidas restantes: {vidas}")

        linha = int(input("\nDigite a linha do tiro (0-9): "))
        coluna_letra = input("Digite a coluna do tiro (A-J): ")

        # Converte a letra da coluna para o número correspondente
        coluna = coluna_letra_para_numero.get(coluna_letra.upper())

        resultado_tiro = verificar_tiro(tabuleiro_navios, tabuleiro_tiros, linha, coluna, mostrar_navios)

        if resultado_tiro:
            tiros_consecutivos += 1
            if tiros_consecutivos == 3:
                vidas += 1
                tiros_consecutivos = 0
        else:            
            vidas -= 1
            tiros_consecutivos = 0

        # Verifica se todos os navios foram abatidos
        navios_restantes = sum(
            tabuleiro_navios[i].count('P') + tabuleiro_navios[i].count('C') + tabuleiro_navios[i].count('T') +
            tabuleiro_navios[i].count('R')
            for i in range(TamanhoDoTabuleiro))
        if navios_restantes == 0:
            print("\nParabéns! Você abateu todos os navios. Você é o Vencedor!")
            break

    if vidas == 0:
        print("\nSuas vidas acabaram. Você precisa treinar mais.")

if __name__ == "__main__":
    jogo_batalha_naval()
