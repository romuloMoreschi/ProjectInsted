#Elaborar um algoritmo que leia duas matrizes M(4,6) e N(6,4) e crie uma matriz que seja:
# a) o produto matricial de M por N;
# b) a soma das linhas de M com as colunas de N; 
# Escrever as matrizes lidas e as calculadas

# M = []
# N = []

# print("Digite os elementos da matriz M(4,6):")
# for i in range(4):
    # linha = []
    # for j in range(6):
        # elemento = int(input(f"Elemento M[{i}][{j}]: "))
        # linha.append(elemento)
    # M.append(linha)

# print("\nDigite os elementos da matriz N(6,4):")
# for i in range(6):
    # linha = []
    # for j in range(4):
        # elemento = int(input(f"Elemento N[{i}][{j}]: "))
        # linha.append(elemento)
    # N.append(linha)

M = [
    [1, 2, 3, 4, 5, 6],
    [7, 8, 9, 10, 11, 12],
    [13, 14, 15, 16, 17, 18],
    [19, 20, 21, 22, 23, 24]
]

N = [
    [1, 2, 3, 4],
    [5, 6, 7, 8],
    [9, 10, 11, 12],
    [13, 14, 15, 16],
    [17, 18, 19, 20],
    [21, 22, 23, 24]
]    

produtoMatricial = []
for i in range(len(M)):
    linhaProduto = []
    for j in range(len(N[0])):
        soma = 0
        for k in range(len(N)):
            soma += M[i][k] * N[k][j]
        linhaProduto.append(soma)
    produtoMatricial.append(linhaProduto)

somaLinhasColunas = []
for i in range(len(M)):
    linhaSoma = []
    for j in range(len(N[0])):
        soma = 0
        for k in range(len(N)):
            soma += M[i][k] + N[k][j]
        linhaSoma.append(soma)
    somaLinhasColunas.append(linhaSoma)

print("\nProduto matricial de M por N:")
for linha in produtoMatricial:
    print(linha)

print("\nSoma das linhas de M com as colunas de N:")
for linha in somaLinhasColunas:
    print(linha)
