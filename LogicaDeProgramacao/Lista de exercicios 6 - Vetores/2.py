#Faça um programa que preencha um vetor com sete elementos numéricos inteiros. Calcule e mostre:
# * os números múltiplos de 2;
# * os números múltiplos de 3;
# * os números múltiplos de 2 e de 3;

vetor = [28, 33, 77, 88, 99, 25, 15878]

# vetorMultiplosDeDois = [num for num in vetor if num % 2 == 0]
# vetorMultiplosDeTres = [num for num in vetor if num % 3 == 0]
# vetorMultiplosDeDoisETres = [num for num in vetor if (num % 2 == 0) or (num % 3 == 0)]

vetorMultiplosDeDois = []
vetorMultiplosDeTres = []
vetorMultiplosDeDoisETres = []

for i in range(len(vetor)):
    if vetor[i] % 2 == 0:
        vetorMultiplosDeDois.append(vetor[i])
    elif vetor[i] % 3 == 0:
        vetorMultiplosDeTres.append(vetor[i])
    
    if (vetor[i] % 2 == 0) or (vetor[i] % 3 == 0):
        vetorMultiplosDeDoisETres.append(vetor[i])

print("\nTodos os números multiplos de 2: ", vetorMultiplosDeDois)    
print("\nTodos os números multiplos de 3: ", vetorMultiplosDeTres)    
print("\nTodos os números multiplos de 2 e 3: ", vetorMultiplosDeDoisETres)    