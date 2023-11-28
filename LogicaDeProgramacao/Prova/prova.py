codigos_vendedores = [105, 287, 959]
vendas_trimestrais = [
    [1000.65, 32598.32, 45987.95],
    [95236.54, 265478.61, 3625874.47],
    [589524.54, 12538.87, 84987.98],
    [548736.74, 875478.62, 4862.25]
]

def cadastrar_funcionarios():
    print("\nSó serão aceitos códigos com valor superior a 1000 " +
          "múltiplos de 5")
    codigo = int(input("Digite o código do funcionario novo: "))
    if (codigo > 1000) and (codigo % 5 == 0):
        codigos_vendedores.append(codigo)
        print("Funcionario cadastrado com sucesso!")
    else:
        print("Código inválido!")
    
def cadastrar_vendas_funcionario():
    numero_a_cadastrar = int(input("Digite o numero de vendas a cadastrar: "))
    for i in range(numero_a_cadastrar):
        linha_vendas = []
        for j in range(len(codigos_vendedores)):
            venda = float(input(f"\nVenda [{i}][{j}]: "))
            linha_vendas.append(venda)
        vendas_trimestrais.append(linha_vendas)
        
def consultar_somatorio_vendas_funcionario():
    indice_funcionario = int(input("Digite o indice do funcionario que deseja consultar: "))
    if (indice_funcionario > len(codigos_vendedores)) or (indice_funcionario < 0):
        print("Funcionario não encontrado!")
    else:
        soma = 0
        for i in range(len(vendas_trimestrais[indice_funcionario])):
            soma += vendas_trimestrais[i][indice_funcionario]    
        print("O somatório das vendas são: ", soma)

def consultar_somatorio_valor_vendas_funcionario():
    indice_funcionario = int(input("Digite o indice do funcionario que deseja consultar: "))
    if (indice_funcionario > len(codigos_vendedores)) or (indice_funcionario < 0):
        print("Funcionario não encontrado!")
    else:
        soma = 0
        for i in range(len(vendas_trimestrais[indice_funcionario])):
            soma += vendas_trimestrais[indice_funcionario][i]   
        print("O somatório das vendas trimestrais são: ", soma)
        

def consultar_codigo_funcionario_maior_valor_vendas():
    if len(codigos_vendedores) > 0:
        indice_funcinario_maior_venda = 999
        somador1 = 0
        somador2 = 0
        total_funcionario = len(codigos_vendedores)
        while total_funcionario > 0:
            for i in range(len(codigos_vendedores)):
                for j in range(len(vendas_trimestrais[i])):
                    somador1 += vendas_trimestrais[i][j]
                if somador1 > somador2:
                    somador2 = somador1
                    indice_funcinario_maior_venda = i
            total_funcionario -= 1
        print("Funcionario com maior venda é: ", indice_funcinario_maior_venda)
    else:
        print("Nenhum funcionario cadastrado!!")    

def main ():
    menu = 999

    while menu != 0 :
        print("Menu\n" +
              "1 - Cadastrar código de funcionarios\n" +
              "2 - Cadastrar vendas trimestrais dos funcionarios\n" +
              "3 - Consultar o somatório do valor das vendas de um funcionario\n" +
              "4 - Consultar o somatório de vendas de um funcionario trimestrais\n" +
              "5 - Mostrar o código de um funcionario com maior valor de vendas\n" +
              "6 - Finalizar programa\n")
        menu = int(input("Digite a opção desejada: "))
        
        if menu == 1:
            cadastrar_funcionarios()
        elif menu == 2:
            cadastrar_vendas_funcionario()
        elif menu == 3:
            consultar_somatorio_vendas_funcionario()
        elif menu == 4:
            consultar_somatorio_valor_vendas_funcionario()
        elif menu == 5:
            consultar_codigo_funcionario_maior_valor_vendas()
        else:
            exit()     
            
main()