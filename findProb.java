import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class findProb {

	public static void main(String[] args) {
		System.out.println("Printing the file passed in:");
		BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
		try {
			StringBuffer stringBuffer = new StringBuffer();
			String line;
			String result;
			while ((line = br.readLine()) != null) {
				if(line.toLowerCase().contains("problem")){
					result = "yes";
				}else {
					result = "no";
					
				}
				stringBuffer.append(result);
				stringBuffer.append("\n");
				}
			System.out.println(stringBuffer.toString());
		} catch (IOException e) {
			e.printStackTrace();
		}

	}

}