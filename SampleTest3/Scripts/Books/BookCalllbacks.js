// TEST NOTE: Create two functions, SuccessfulRequest and FailedRequest, that will take in the response parameter and prompt
//            the user a confirmation message
function SuccessfulRequest(result) {
    $("#ajax-results").text(result.text);
};

function FailedRequest(result) {
    $("#ajax-results").text(result.text);
};