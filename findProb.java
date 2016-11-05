import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.concurrent.TimeUnit;

public class findProb {

	public static void main(String[] args) throws IOException {
		long startTime = System.currentTimeMillis();
		try(BufferedReader br = new BufferedReader(new InputStreamReader(System.in))){
			StringBuffer stringBuffer = new StringBuffer();
			try{
				String line;
				String result;
				while ((line = br.readLine()) != null && line.length()!=0) {
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
			throw e;
		}

	}
      long stopTime = System.currentTimeMillis();
      long elapsedTime = stopTime - startTime;
      System.out.println(elapsedTime);
	}
}
