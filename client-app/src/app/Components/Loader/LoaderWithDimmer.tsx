import { observer } from 'mobx-react-lite';
import React from 'react';
import { Dimmer, Loader, SemanticSIZES } from 'semantic-ui-react';

interface ILoaderWithDimmer {
  active?: boolean;
  content?: string;
  inverted?: boolean;
  size?: SemanticSIZES;
}

const LoaderWithDimmer = ({
  content,
  size,
  inverted,
  active = true,
}: ILoaderWithDimmer) => {
  return (
    <Dimmer active={active}>
      <Loader content={content} size={size} inverted={inverted} />
    </Dimmer>
  );
};

export default observer(LoaderWithDimmer);
