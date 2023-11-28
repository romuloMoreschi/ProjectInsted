#Faça um programa para controlar o estoque de mercadorias de uma empresa. Inicialmente, 
#o programa deverá preencher dois vetores em dez posições cada, onde o primeiro corresponde 
#ao código do protudo e o segundo, ao total desse produto em estoque. Logo após, o programa 
#deverá ler um conjunto indeterminado de dados contendo o código de um client e o código do
#produto que ele deseja comprar, juntamente com a quantidade. Código do cliente igual a zero indica
#fim do programa. O programa deverá verificar:
# * se o código do produto solicitado existe. Se existir, tentar atender ao pedido; caso contrário, exibir
#mensagem Código inexistente;
# * cada pedido feito por um cliente só pode ser atendido integralmente. Caso isso não seja possivel, escrever
#a mensagem Pedido atentido. Obrigado e volte sempre;
#efetura a atualização do estoque somente se o pedido for atendido integralmente;
#no final do programa, escrever os códigos dos produtos com ses respectivos estoques já atualizados.

codigos_produtos = [255, 333, 44215, 1, 8872, 366, 664, 44, 99, 7]
estoque_produtos = [4, 5, 6, 9, 1, 2, 5, 5, 1, 2]

codigo_cliente = 1

while codigo_cliente != 0:
    codigo_cliente = int(input("Digite o codigo do cliente: "))
    if codigo_cliente == 0:
        break
    
    codigo_produto = int(input("Digite o codigo do produto que o client deseja: "))
    quantidade_desejada = int(input("Digite a quantidade desejada do produto: "))

    existe = False
    idProduto = 0

    for i in range(len(codigos_produtos)):
        if codigo_produto == codigos_produtos[i]:
            existe = True
            idProduto = i            

    if existe == False:
        print("\nCódigo inexistente!")
    else:        
        if estoque_produtos[idProduto] >= quantidade_desejada:
            print("\nPedido atendido. Obrigado e volte sempre!")
            estoque_produtos[idProduto] -= quantidade_desejada
        else:
            print("\nNão temos estoque suficiente dessa nercadoria!")

print("\nCódigos dos produtos: ", codigos_produtos)
print("Estoque dos produtos: ", estoque_produtos)

# estoque = { 255: 4, 333: 5, 44215: 6, 1: 9, 8872: 1, 366: 2, 664: 5, 44: 5, 99: 1, 7: 2 }

# codigo_cliente = 1

# while codigo_cliente != 0:
    # codigo_cliente = int(input("Digite o código do cliente (ou 0 para sair): "))
    # if codigo_cliente == 0:
        # break
    
    # codigo_produto = int(input("Digite o código do produto desejado: "))
    # quantidade_desejada = int(input("Digite a quantidade desejada: "))

    # if codigo_produto not in estoque:
        # print("\nCódigo inexistente!")
    # elif estoque[codigo_produto] >= quantidade_desejada:
        # print("\nPedido atendido. Obrigado e volte sempre!")
        # estoque[codigo_produto] -= quantidade_desejada
    # else:
        # print("\nNão temos estoque suficiente desse produto!")

# print("\nCódigos dos produtos:", list(estoque.keys()))
# print("Estoque dos produtos:", list(estoque.values()))