import React from 'react';
import { observer } from 'mobx-react-lite';
import { Loader, SemanticSIZES } from 'semantic-ui-react';

interface ILoaderWithoutDimmer {
  active?: boolean;
  content?: string;
  inverted?: boolean;
  size?: SemanticSIZES;
}

const LoaderWithoutDimmer = ({
  size,
  content,
  inverted,
  active = true,
}: ILoaderWithoutDimmer) => {
  return (
    <Loader active={active} content={content} size={size} inverted={inverted} />
  );
};

export default observer(LoaderWithoutDimmer);
