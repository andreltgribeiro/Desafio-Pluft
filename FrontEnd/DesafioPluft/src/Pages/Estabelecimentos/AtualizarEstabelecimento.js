import React, { Component } from 'react';
import { StyleSheet, Text, Image, TextInput, View, TouchableOpacity, AsyncStorage, Alert } from 'react-native';
import { ScrollView } from 'react-native-gesture-handler';
import api from '../../services/api'

class AtualizarEstabelec extends Component {
  static navigationOptions = {
    tabBarIcon: ({ tintColor }) => (
      <Image
        source={require("../../assets/img/refresh.png")}
        style={styles.tabNavigatorIconHome}
      />
    )
  };

  constructor(props) {
    super(props);
    this.state = {
      id: '',
      Nome: '',
      cnpj: '',
      IdTipoEstabelec: '',
      endereco: '',
      horariofuncionamento: '',
      vagas: ''
    }
  }

  _Atualizar = async () => {
    if (this.state.id == null || this.state.id == '' || this.state.id == 0) {
      Alert.alert(
        "Erro",
        "Informe um Id Válido",
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
        if (this.state.cnpj == null || this.state.cnpj == '' || this.state.cnpj.length > 14) {
          Alert.alert(
            "Erro",
            "Informe um cnpj válido",
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
          if (this.state.IdTipoEstabelec == null || this.state.IdTipoEstabelec == '' || this.state.IdTipoEstabelec == 0) {
            Alert.alert(
              "Erro",
              "Informe um Id de tipo de estabelecimento",
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
            if (this.state.endereco == null || this.state.endereco == '') {
              Alert.alert(
                "Erro",
                "Informe um endereço",
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
              if (this.state.horariofuncionamento == null || this.state.horariofuncionamento == '') {
                Alert.alert(
                  "Erro",
                  "Informe um horário de funcionamento",
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
                if (this.state.vagas == null || this.state.vagas == '') {
                  Alert.alert(
                    "Erro",
                    "Informe o número de vagas",
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

                  await api.put("/estabelecimentos", {
                    id: this.state.id,
                    Nome: this.state.Nome,
                    cnpj: this.state.cnpj,
                    IdTipoEstabelec: this.state.IdTipoEstabelec,
                    endereco: this.state.endereco,
                    horariofuncionamento: this.state.horariofuncionamento,
                    vagas: this.state.vagas
                  }, {
                      headers: {
                        "Content-Type": "application/json",
                        "Authorization": "Bearer " + value
                      },


                    });
                  Alert.alert(
                    "Parabéns",
                    "Você Atualizou um Estabelecimento",
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
          <Text style={styles.titulo}>Atualizar Estabelecimento</Text>
          <View style={styles.linhaTitulo} />
        </View>
        <View style={styles.body}>
          <TextInput style={styles.input}
            autoCapitalize="none"
            returnKeyType="next"
            placeholder='Id do estabelecimento que deseja atualizar'
            onChangeText={id => this.setState({ id })}
            placeholderTextColor='rgb(161, 162, 163)' />


          <TextInput style={styles.input}
            autoCapitalize="none"
            returnKeyType="next"
            placeholder='Novo Nome do Estabelecimento'
            onChangeText={Nome => this.setState({ Nome })}
            placeholderTextColor='rgb(161, 162, 163)' />


          <ScrollView>
            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Novo CNPJ (Até 14 caracteres)'
              onChangeText={cnpj => this.setState({ cnpj })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Novo Id Tipo Estabelecimento'
              onChangeText={IdTipoEstabelec => this.setState({ IdTipoEstabelec })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Novo Endereço'
              onChangeText={endereco => this.setState({ endereco })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Novo Horário de Funcionamento'
              onChangeText={horariofuncionamento => this.setState({ horariofuncionamento })}
              placeholderTextColor='rgb(161, 162, 163)' />


            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Novo número de Vagas'
              onChangeText={vagas => this.setState({ vagas })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TouchableOpacity style={styles.buttonContainer}
              onPress={this._Atualizar}
            >
              <Text style={styles.buttonText}>Confirmar</Text>
            </TouchableOpacity>
          </ScrollView>
        </View>
      </View>
    );
  }
}
export default AtualizarEstabelec;


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