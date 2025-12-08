// ============================ PROVA FINAL LPR2 ============================
/*
    DUPLA:
    Adriano Júnior de Souza Almeida - CB3030644
    Arthur Lanzilotti Farjanes - CB3031306

    ENUNCIADO:
    Crie uma tela para cadastro de pacientes de um hospital com os seguintes 
    requisitos, os campos são obrigatórios em Banco de Dados:
    1. ID (automático)
    2. Nome (String)
    3. Idade (int)
    4. Peso (float)
    5. Altura (float)
    
    A tela deve conter os seguintes botões:
    1. Incluir (registra no banco de dados, somente consistência do tipo de
    dados / int, float e etc.. )
    2. Limpar
    3. Apresenta Dados
    4. Pesquisar (por nome usando like em Banco de Dados)
    5. Botão para apresentar créditos da dupla em um Painel.
    6. Sair

    Critérios de avaliação:
    Layout da tela com todos os requisitos (1,0)
    Inclusão no banco de dados (4,0)
    Apresenta dados em um JOptionPane (2,0)
    Pesquisa por nome (2,0)
    Sair e Limpar (1,0)
*/

import javax.swing.SwingUtilities;

public class Main {
    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            TelaCadastro tela = new TelaCadastro();
            tela.setVisible(true);
        });
    }
}