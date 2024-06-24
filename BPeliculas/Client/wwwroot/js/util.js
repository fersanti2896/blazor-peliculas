
function testPuntoNetStatic() {
    DotNet.invokeMethodAsync("BPeliculas.Client", "getCurrentCount")
          .then(result => {
              console.log("Conteo desde javascript: ", result);
          });
}

function testInstance(helper) {
    helper.invokeMethodAsync("incrementCount");
}