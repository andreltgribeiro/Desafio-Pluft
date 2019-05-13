import React, { Component } from 'react';
import { StyleSheet, Text, Image, TextInput, View, TouchableOpacity, AsyncStorage, Alert } from 'react-native';
import { ScrollView } from 'react-native-gesture-handler';
import api from '../../services/api'

class CadastrarAdm extends Component {
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
      IdTipoUsuario: ''
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
            if (this.state.IdTipoUsuario == null || this.state.IdTipoUsuario == '' || this.state.IdTipoUsuario == 0) {
              Alert.alert(
                "Erro",
                "Informe um Id Tipo de Usuário",
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

              await api.post("/usuarios/administrador", {
                Nome: this.state.Nome,
                Email: this.state.Email,
                Senha: this.state.Senha,
                Telefone: this.state.Telefone,
                IdTipoUsuario: this.state.IdTipoUsuario
              }, {
                  headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + value
                  },


                });
              Alert.alert(
                "Parabéns",
                "Você Cadastrou um Administrador",
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


  render() {
    return (
      <View>
        <View style={styles.cabecalho}>
          <Text style={styles.titulo}>Cadastrar Administrador</Text>
          <View style={styles.linhaTitulo} />
        </View>
        <View style={styles.body}>
          <TextInput style={styles.input}
            autoCapitalize="none"
            returnKeyType="next"
            placeholder='Nome do Administrador'
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
              placeholder='Id Tipo Usuário'
              onChangeText={IdTipoUsuario => this.setState({ IdTipoUsuario })}
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
export default CadastrarAdm;


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