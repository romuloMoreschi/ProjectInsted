#Faça um programa que preencha um vetor com seis elementos numéricos inteiros. Calcule e mostre:
# * todos os números pares;
# * a quantidade de números pares;
# * todos os números ímpares;

vetor = [10, 3, 7, 8, 9, 2]
vetorPares = []
vetorImpares = []

contaNumerosPares = 0
contaNumerosImpares = 0

# vetorPares = [num for num in vetor if num % 2 == 0]
# vetorImpares = [num for num in vetor if num % 2 != 0]

# contaNumerosPares = len(vetorPares)
# contaNumerosImpares = len(vetorImpares)

for i in range(len(vetor)):
    if vetor[i] % 2 == 0:
        contaNumerosPares += 1
        vetorPares.append(vetor[i])
    else:
        contaNumerosImpares += 1
        vetorImpares.append(vetor[i])
        
print("\nTodos os números pares: ", vetorPares)    
print("Total de numeros pares: ", contaNumerosPares)
print("\nTodos os números ímpares: ", vetorImpares)    
print("Total de numeros ímpares: ", contaNumerosImpares)