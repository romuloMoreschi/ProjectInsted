#Escreva um algoritmo que leia um número inteiro A e uma matriz V 30x30 de inteiros.
#Conte quantos valores iguais a A estão na matriz. Crie, a seguir, uma matriz X
#contendo todos os elementos de V diferentes de A. Mostre os resultados. (Obs: Pode
#ser que nem todas as posições da matriz X sejam ocupadas)



matriz30x30 = [[i * 30 + j + 1 for j in range(30)] for i in range(30)]

print(matriz30x30)