import React, { Component } from 'react';
import { StyleSheet, Text, Image, TextInput, View, TouchableOpacity, AsyncStorage, Alert } from 'react-native';
import { ScrollView } from 'react-native-gesture-handler';
import api from '../../services/api'

class CadastrarCliente extends Component {
  static navigationOptions = {
    tabBarIcon: ({ tintColor }) => (
      <Image
        source={require("../../assets/img/add.png")}
        style={styles.tabNavigatorIconHome}
      />
    )
  };

  constructor(props) {
    super(props);
    this.state = {
      Nome: '',
      Email: '',
      Senha: '',
      Telefone: '',
      Cpf: '',
      DataNascimento: '',
      Rg: '',
      Endereco: ''
    }
  }

  _cadastrar = async () => {

    if (this.state.Nome == null || this.state.nome == '') {
      Alert.alert(
        "Erro",
        "Informe um nome",
        [
          { text: "Later", onPress: () => console.log("later pressed") },
          {
            text: "Cancel",
            onPress: () => console.log("Cancel Pressed"),
            style: "cancel"
          },
          { text: "OK", onPress: () => console.log("OK Pressed") }
        ],
        { cancelable: false }
      );
    } else {
      if (this.state.Email == null || this.state.Email == '') {
        Alert.alert(
          "Erro",
          "Informe um Email",
          [
            { text: "Later", onPress: () => console.log("later pressed") },
            {
              text: "Cancel",
              onPress: () => console.log("Cancel Pressed"),
              style: "cancel"
            },
            { text: "OK", onPress: () => console.log("OK Pressed") }
          ],
          { cancelable: false }
        );
      } else {
        if (this.state.Senha == null || this.state.Senha == '') {
          Alert.alert(
            "Erro",
            "Informe uma Senha",
            [
              { text: "Later", onPress: () => console.log("later pressed") },
              {
                text: "Cancel",
                onPress: () => console.log("Cancel Pressed"),
                style: "cancel"
              },
              { text: "OK", onPress: () => console.log("OK Pressed") }
            ],
            { cancelable: false }
          );
        } else {
          if (this.state.Telefone == null || this.state.Telefone == '') {
            Alert.alert(
              "Erro",
              "Informe um Telefone",
              [
                { text: "Later", onPress: () => console.log("later pressed") },
                {
                  text: "Cancel",
                  onPress: () => console.log("Cancel Pressed"),
                  style: "cancel"
                },
                { text: "OK", onPress: () => console.log("OK Pressed") }
              ],
              { cancelable: false }
            );
          } else {

            if (this.state.DataNascimento == null || this.state.DataNascimento == '') {
              Alert.alert(
                "Erro",
                "Informe uma data de nascimento",
                [
                  { text: "Later", onPress: () => console.log("later pressed") },
                  {
                    text: "Cancel",
                    onPress: () => console.log("Cancel Pressed"),
                    style: "cancel"
                  },
                  { text: "OK", onPress: () => console.log("OK Pressed") }
                ],
                { cancelable: false }
              );
            } else {
              if (this.state.Rg == null || this.state.Rg == '' || this.state.Rg.length > 9) {
                Alert.alert(
                  "Erro",
                  "Informe um RG válido",
                  [
                    { text: "Later", onPress: () => console.log("later pressed") },
                    {
                      text: "Cancel",
                      onPress: () => console.log("Cancel Pressed"),
                      style: "cancel"
                    },
                    { text: "OK", onPress: () => console.log("OK Pressed") }
                  ],
                  { cancelable: false }
                );
              } else {
                if (this.state.Endereco == null || this.state.Endereco == '') {
                  Alert.alert(
                    "Erro",
                    "Informe um Endereço",
                    [
                      { text: "Later", onPress: () => console.log("later pressed") },
                      {
                        text: "Cancel",
                        onPress: () => console.log("Cancel Pressed"),
                        style: "cancel"
                      },
                      { text: "OK", onPress: () => console.log("OK Pressed") }
                    ],
                    { cancelable: false }
                  );
                } else {
                  if (this.state.Cpf == null || this.state.Cpf == '' || this.state.Cpf.length > 11) {
                    Alert.alert(
                      "Erro",
                      "Informe um CPF válido",
                      [
                        { text: "Later", onPress: () => console.log("later pressed") },
                        {
                          text: "Cancel",
                          onPress: () => console.log("Cancel Pressed"),
                          style: "cancel"
                        },
                        { text: "OK", onPress: () => console.log("OK Pressed") }
                      ],
                      { cancelable: false }
                    );
                  } else {

                    const value = await AsyncStorage.getItem("userToken");

                    await api.post("/usuarios/cliente", {
                      Nome: this.state.Nome,
                      Email: this.state.Email,
                      Senha: this.state.Senha,
                      Telefone: this.state.Telefone,
                      Cpf: this.state.Cpf,
                      DataNascimento: this.state.DataNascimento,
                      Rg: this.state.Rg,
                      Endereco: this.state.Endereco
                    }, {
                        headers: {
                          "Content-Type": "application/json",
                          "Authorization": "Bearer " + value
                        },


                      });
                    Alert.alert(
                      "Parabéns",
                      "Você Cadastrou um Cliente",
                      [
                        { text: "Later", onPress: () => console.log("later pressed") },
                        {
                          text: "Cancel",
                          onPress: () => console.log("Cancel Pressed"),
                          style: "cancel"
                        },
                        { text: "OK", onPress: () => console.log("OK Pressed") }
                      ],
                      { cancelable: false }
                    );
                    this.props.navigation.navigate("AdministradorStack");
                  }
                }
              }
            }
          }
        }
      }
    }

  }


  render() {
    return (
      <View>
        <View style={styles.cabecalho}>
          <Text style={styles.titulo}>Cadastrar Cliente</Text>
          <View style={styles.linhaTitulo} />
        </View>
        <View style={styles.body}>
          <TextInput style={styles.input}
            autoCapitalize="none"
            returnKeyType="next"
            placeholder='Nome do Cliente'
            onChangeText={Nome => this.setState({ Nome })}
            placeholderTextColor='rgb(161, 162, 163)' />

          <ScrollView>
            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Email'
              onChangeText={Email => this.setState({ Email })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Senha'
              onChangeText={Senha => this.setState({ Senha })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Telefone'
              onChangeText={Telefone => this.setState({ Telefone })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Data De Nascimento (mm-dd-yyyy)'
              onChangeText={DataNascimento => this.setState({ DataNascimento })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Rg (Até 9 caracteres)'
              onChangeText={Rg => this.setState({ Rg })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Endereço'
              onChangeText={Endereco => this.setState({ Endereco })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='CPF (Até 11 caracteres)'
              onChangeText={Cpf => this.setState({ Cpf })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TouchableOpacity style={styles.buttonContainer}
              onPress={this._cadastrar}
            >
              <Text style={styles.buttonText}>Confirmar</Text>
            </TouchableOpacity>
          </ScrollView>
        </View>
      </View>
    );
  }
}
export default CadastrarCliente;


const styles = StyleSheet.create({
  body: {
    justifyContent: 'center',
    alignItems: 'center'
  },
  tabNavigatorIconHome: {
    width: 25,
    height: 25,
    // tintColor: "purple"
    tintColor: "#FFFFFF"
  },
  container: {
    padding: 20
  },
  input: {
    height: 40,
    backgroundColor: 'rgba(225,225,225,0.2)',
    marginBottom: 10,
    padding: 10,
    color: 'black',
    width: 376
  },
  buttonContainer: {
    backgroundColor: 'rgb(94, 155, 255)',
    paddingVertical: 15,
    width: 376,
  },
  buttonText: {
    color: '#fff',
    textAlign: 'center',
    fontWeight: '700'
  },
  titulo: {
    fontSize: 16,
    letterSpacing: 1
  },
  cabecalho: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    marginTop: 30,
    marginBottom: 30
  },

  linhaTitulo: {
    width: 100,
    borderBottomColor: "#999999",
    borderBottomWidth: 0.9,
    marginBottom: 8,
    marginTop: 2
  }
});