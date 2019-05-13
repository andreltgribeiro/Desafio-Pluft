import React, { Component } from 'react';
import { StyleSheet, Text, Image, TextInput, View, TouchableOpacity, AsyncStorage, Alert } from 'react-native';
import { ScrollView } from 'react-native-gesture-handler';
import api from '../../services/api'

class CadastrarAgendamentos extends Component {
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
      idcliente: '',
      IdEstabelecimento: '',
      IdStatus: '',
      IdLojista: '',
      DataAgendamento: ''
    }
  }

  _cadastrar = async () => {

    if (this.state.idcliente == null || this.state.idcliente == '' || this.state.idcliente == 0) {
      Alert.alert(
        "Erro",
        "Informe o id do cliente",
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

      if (this.state.IdEstabelecimento == null || this.state.IdEstabelecimento == '' || this.state.IdEstabelecimento == 0) {
        Alert.alert(
          "Erro",
          "Informe o id do estabelecimento",
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
        if (this.state.IdStatus == null || this.state.IdStatus == '' || this.state.IdEstabelecimento == 0) {
          Alert.alert(
            "Erro",
            "Informe o is do status",
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
          if (this.state.IdLojista == null || this.state.IdLojista == '' || this.state.IdLojista == 0) {
            Alert.alert(
              "Erro",
              "Informe o id do lojista",
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
            if (this.state.DataAgendamento == null || this.state.DataAgendamento == '') {
              Alert.alert(
                "Erro",
                "Informe a data de seu agendamento (mm-dd-yyyy)",
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

            const value = await AsyncStorage.getItem("userToken");

            await api.post("/agendamentos", {
              idcliente: this.state.idcliente,
              IdEstabelecimento: this.state.IdEstabelecimento,
              IdLojista: this.state.IdLojista,
              IdStatus: this.state.IdStatus,
              DataAgendamento: this.state.DataAgendamento
            }, {
                headers: {
                  "Content-Type": "application/json",
                  "Authorization": "Bearer " + value
                },


              });
            Alert.alert(
              "Parabéns",
              "Você Cadastrou um Agendamento",
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


  render() {
    return (
      <View>
        <View style={styles.cabecalho}>
          <Text style={styles.titulo}>Cadastrar Agendamento</Text>
          <View style={styles.linhaTitulo} />
        </View>
        <View style={styles.body}>
          <TextInput style={styles.input}
            autoCapitalize="none"
            returnKeyType="next"
            placeholder='Id do cliente'
            onChangeText={idcliente => this.setState({ idcliente })}
            placeholderTextColor='rgb(161, 162, 163)' />

          <ScrollView>
            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Id do estabelecimento'
              onChangeText={IdEstabelecimento => this.setState({ IdEstabelecimento })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Id do lojista'
              onChangeText={IdLojista => this.setState({ IdLojista })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='id status'
              onChangeText={IdStatus => this.setState({ IdStatus })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Informe a data de seu agendamento (mm-dd-yyyy)'
              onChangeText={DataAgendamento => this.setState({ DataAgendamento })}
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
export default CadastrarAgendamentos;


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