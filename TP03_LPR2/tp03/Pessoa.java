package tp03;

public class Pessoa {
	
	private static int kp = 0; 
	private String nome;       
    private char sexo;         
    private int idade;        

    public Pessoa() {
       
    }

    public Pessoa(String nome, char sexo, int idade) {
        this.nome = nome;
        this.sexo = sexo;
        this.idade = idade;
        setKp(); 
    }
    
    public static void setKp() {  
        Pessoa.kp++;
    }
    
    public void setNome(String nome) {
        this.nome = nome;
    }

    public void setSexo(char sexo) {
        this.sexo = sexo;
    }

    public void setIdade(int idade) {
        this.idade = idade;
    }
    
    public static int getKp() {
        return Pessoa.kp;
    }

    public String getNome() {
        return nome;
    }
 
    public char getSexo() {
        return sexo;
    }

    public int getIdade() {
        return idade;
    }
}
