import random

# Constantes
TamanhoDoTabuleiro = 10
VidasIniciais = 5
Direcoes = [(0, 1), (1, 0)]  # horizontal, vertical
Navios = {'P': 1, 'C': 1, 'T': 2, 'R': 3}  # Quantidade de células ocupadas por cada tipo de navio

# Mapeia letras para números (A-J)
coluna_letra_para_numero = {'A': 0, 'B': 1, 'C': 2, 'D': 3, 'E': 4, 'F': 5, 'G': 6, 'H': 7, 'I': 8, 'J': 9}

# Função para criar o tabuleiro com os navios
def criar_tabuleiro():
    return [[' ' for _ in range(TamanhoDoTabuleiro)] for _ in range(TamanhoDoTabuleiro)]

# Função para imprimir o tabuleiro com ocultação dos navios
def imprimir_tabuleiro(tabuleiro, mostrar_navios=False):
    print("  A B C D E F G H I J")
    for i in range(TamanhoDoTabuleiro):
        linha_exibicao = []
        for j in range(TamanhoDoTabuleiro):
            if tabuleiro[i][j] == 'X':
                linha_exibicao.append('X')
            elif mostrar_navios or tabuleiro[i][j] == ' ':
                linha_exibicao.append(tabuleiro[i][j])
            elif tabuleiro[i][j] == 'O':  
                linha_exibicao.append('O')
            else:
                linha_exibicao.append(' ')
        print(i, ' '.join(linha_exibicao))

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
    for navio, tamanho in Navios.items():
        for _ in range(tamanho):
            while True:
                direcao = random.choice(Direcoes)
                linha = random.randint(0, TamanhoDoTabuleiro - 1)
                coluna = random.randint(0, TamanhoDoTabuleiro - 1)

                # Verifica se é possível posicionar o navio naquela direção
                if posicao_valida(tabuleiro, linha, coluna, tamanho, direcao):
                    for i in range(tamanho):
                        nova_linha = linha + i * direcao[0]
                        nova_coluna = coluna + i * direcao[1]
                        tabuleiro[nova_linha][nova_coluna] = navio
                    break

# Função para verificar se o jogador acertou um navio
def verificar_tiro(tabuleiro, linha, coluna):
    if tabuleiro[linha][coluna] != ' ':
        navio = tabuleiro[linha][coluna]
        tabuleiro[linha][coluna] = 'X'  # Marcar como atingido
        return navio
    else:
        # Adiciona marcação para indicar tiro na água
        tabuleiro[linha][coluna] = 'O'
        return None

# Função principal do jogo
def jogo_batalha_naval():
    tabuleiro = criar_tabuleiro()
    posicionar_navios(tabuleiro)
    vidas = VidasIniciais
    tiros_consecutivos = 0

    while vidas > 0:
        print(f"\nVidas restantes: {vidas}")
        imprimir_tabuleiro(tabuleiro)

        linha = int(input("\nDigite a linha do tiro (0-9): "))
        coluna_letra = input("Digite a coluna do tiro (A-J): ")

        # Converte a letra da coluna para o número correspondente
        coluna = coluna_letra_para_numero.get(coluna_letra.upper())

        resultado_tiro = verificar_tiro(tabuleiro, linha, coluna)

        if resultado_tiro:
            print(f"\nAcertou um navio: {resultado_tiro}")
            tiros_consecutivos += 1
            if tiros_consecutivos == 3:
                vidas += 1
                tiros_consecutivos = 0
        else:
            print("\nÁgua! Você errou o tiro.")
            vidas -= 1
            tiros_consecutivos = 0

        # Verifica se todos os navios foram abatidos
        navios_restantes = sum(tabuleiro[i].count('P') + tabuleiro[i].count('C') + tabuleiro[i].count('T') + tabuleiro[i].count('R') for i in range(TamanhoDoTabuleiro))
        if navios_restantes == 0:
            print("\nParabéns! Você abateu todos os navios. Você é o Vencedor!")
            break

    if vidas == 0:
        print("\nSuas vidas acabaram. Você precisa treinar mais.")


if __name__ == "__main__":
    jogo_batalha_naval()
