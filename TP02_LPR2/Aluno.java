import java.util.UUID;

public class Aluno {
	 private UUID _uuid;
	 private String _nome;
	 private int _idade;
	 private String _endereco;
	 
	 //CONSTRUTOR
	 public Aluno(String n, int i, String e) {
		 this._uuid = UUID.randomUUID();
		 this._nome = n;
		 this._idade = i;
		 this._endereco = e;
	 }
	 
	 //GETTERS
	 public String getNome() {
		 return _nome;
	 }
	 public int getIdade() {
		 return _idade;
	 }
	 public String getEndereco() {
		 return _endereco;
	 }
	 public UUID getUUID() {
		 return _uuid;
	 }
	 
	 //SETTERS
	 public void setNome(String nome)  {
		 if(nome == null || nome == "") {
			 throw new IllegalArgumentException("O nome não pode ser vazio ou nulo.");
		 }
		 this._nome = nome;
	 }
	 public void setIdade(int idade) {
		 if(idade < 0) {
			 throw new IllegalArgumentException("A idade não pode ser um número negativo.");
		 }
		this._idade = idade; 
	 }
	 public void setEndereco(String endereco) {
		 if(endereco == null || endereco == "") {
			 throw new IllegalArgumentException("O endereço não pode ser vazio ou nulo.");
		 }
		 this._endereco = endereco;
	 }
	 public void setUUID(UUID uuid) {
		 this._uuid = uuid;
	 }
}
