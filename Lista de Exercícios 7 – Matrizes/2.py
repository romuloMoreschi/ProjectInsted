#Elaborar um algoritmo que leia uma matriz M(6,6) e um valor A , multiplique a matriz M
#pelo valor A e coloque estes valores em um vetor de V(36). Escreva ao final o vetor V. 

matriz = [
    [1, 2, 3, 4, 5, 6],
    [7, 8, 9, 10, 11, 12],
    [13, 14, 15, 16, 17, 18],
    [19, 20, 21, 22, 23, 24],
    [25, 26, 27, 28, 29, 30],
    [31, 32, 33, 34, 35, 36]
]

# matriz = []

# print("Digite os elementos da matriz M(6,6):")
# for i in range(6):
    # linha = []
    # for j in range(6):
        # elemento = int(input(f"Elemento M[{i}][{j}]: "))
        # linha.append(elemento)
    # matriz.append(linha)

vetor = []
valorA = int(input("Digite o valor de A: "))
for i in range(6):
    for j in range(6):
        valor = valorA * matriz[i][j]
        vetor.append(valor)

print(f"Vetor multiplicado por {valorA} = {vetor}")